const exports = {
    validateWebsiteForm: validateWebsiteForm,
    validateVatNumberForm : validateVatNumberForm,
    validateAddressForm : validateAddressForm,
    validateCreateForm: validateCreateForm
}

export default exports

function validateCreateForm(form){
    return validateAddressForm(form)
}

function validateAddressForm(form){
    var response = validateForm(form)
    delete response.streetExtended
    
    return response
}

function validateVatNumberForm(form){
    var formErrors = {
        changedByIsValid : true,
        vatNumberIsValid : true
    }
    formErrors.vatNumberIsValid = stringNotNullOrEmpty(form.vatNumber)
    formErrors.changedByIsValid = stringNotNullOrEmpty(form.changedBy)
    formErrors.isValid = function () {
        return this.vatNumberIsValid && this.changedByIsValid
    }
    
    return formErrors
}

function validateWebsiteForm(form){
    var formErrors = {
        websiteIsValid : true,
        changedByIsValid : true
    }
    formErrors.websiteIsValid = stringNotNullOrEmpty(form.website)
    formErrors.changedByIsValid = stringNotNullOrEmpty(form.changedBy)
    formErrors.isValid = function () {
        return this.websiteIsValid && this.changedByIsValid
    }
    
    return formErrors
}

function stringNotNullOrEmpty(string){
    return (!string == false)
}

function validateForm(form){
    var entries = Object.entries(form)
    var formErrors = {}
    entries.forEach(element => {
        formErrors[element[0]] = stringNotNullOrEmpty(element[1])
    });

    formErrors.isValid = function() {
        var entries = Object.entries(this)
        var allOk = true

        entries.forEach(error => {
            if (error[1] === false) 
                allOk = error[1]
        })
        return allOk
    }

    return formErrors
}