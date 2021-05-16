using MediatR;
using OrganizationService.EventEmitter.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace OrganizationService.EventEmitter
{
    internal class OrganizationServiceEventEmitter
    {
        private readonly IMediator _mediator;

        public OrganizationServiceEventEmitter(IMediator mediator)
        {       
            _mediator = mediator;
        }
        public async Task Run(string[] args)
        {
            var availableCommands = GetAvailableCommands();
            var commandType = GetCommandType(availableCommands);
            var command = GetCommand(commandType);
            await ExecuteCommand(command);
            
        }

        private async Task ExecuteCommand(object command)
        {
            var requestInterface = command.GetType().GetInterfaces().First();
            var responseParameter = requestInterface.GenericTypeArguments.Last();

            var method = typeof(ISender)
                .GetMethods()
                .First()
                .MakeGenericMethod(responseParameter);

            var action = (Task)method.Invoke(_mediator, new[] { command, CancellationToken.None });

            await action;
        }

        private object GetCommand(Type commandType)
        {
            var constructorInfo = commandType.GetConstructors().SingleOrDefault();
            object request;
            var parameterInfos = constructorInfo.GetParameters();
            if (parameterInfos.Length > 0)
            {
                var parameters = CollectConstructorParameters(parameterInfos);
                request = constructorInfo.Invoke(parameters);
            }
            else
            {
                request = Activator.CreateInstance(commandType);
            }

            return request;
        }

        private object[] CollectConstructorParameters(ParameterInfo[] parameterInfos)
        {
            var parameters = new object[parameterInfos.Length];
            for (int i = 0; i < parameterInfos.Length; i++)
            {
                var parameter = parameterInfos[i];
                Console.WriteLine($"{parameter.Name}: ");
                var parameterInput = Console.ReadLine();
                var actualInput = Convert.ChangeType(parameterInput, parameter.ParameterType);
                parameters[i] = actualInput;
            }

            return parameters;
        }

        private Type GetCommandType(List<Type> availableCommands)
        {
            bool hasValidInput = true;
            Type commandType = null;

            while (hasValidInput)
            {
                PrintAvailableCommands(availableCommands);
                Console.WriteLine("Command: > ");

                var value = Console.ReadLine();
                if (int.TryParse(value, out var key) == false)
                {
                    if (value.Equals("q"))
                        System.Environment.Exit(0);

                    Console.WriteLine($"{value} is not a valid input");
                    continue;
                }

                if (key > availableCommands.Count - 1 || key < 0)
                {
                    Console.WriteLine($"Could not determine command from input {key}. Options are from 0 to {availableCommands.Count}");
                    continue;
                }

                commandType = availableCommands[key];
                hasValidInput = false;
            }
            return commandType;
        }

        private void PrintAvailableCommands(List<Type> availableCommands)
        {
            Console.WriteLine("Available commands:");
            foreach(var availableCommandType in availableCommands)
            {
                Console.WriteLine($"{availableCommands.IndexOf(availableCommandType)}) {availableCommandType.Name}");
            }
            Console.WriteLine("q) Exit EventEmitter");
        }

        private List<Type> GetAvailableCommands()
        {
            var availableCommands = typeof(Program)
                .Assembly
                .GetTypes()
                .Where(x => x.IsAssignableToGenericType(typeof(IRequest<>)))
                .ToList();
            return availableCommands;
        }
    }
}