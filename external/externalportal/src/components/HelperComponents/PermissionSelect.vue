<template>

  <select class="browser-default custom-select" v-bind:value="permission" v-on:input="$emit('input', $event.target.value)" v-model="permission">
      <option v-for="option in permissionOptions" v-bind:key="option.value" v-bind:value="option.value">{{option.text}}</option>
  </select>
</template>
<script>
export default{
  name: 'PermissionSelect',
  props: ['permission'],
  data: () =>({    
    permissionOptions : [{ text: 'SuperAdmin', value: 0},{ text: 'Admin', value:1 },{ text: 'ReadWrite', value:2}, {text:'ReadOnly', value: 3}, {text: 'NoAccess', value:4}]
  })
  
}
</script>
