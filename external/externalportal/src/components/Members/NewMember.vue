<template>
<div>
  <h2>Add Member</h2>
  <mdb-card class="w-75 mb-4">
    <form @submit.prevent="submitForm">
    <mdb-card-header>Add member to Organization</mdb-card-header>
    <mdb-card-body>
      <mdb-card-text>
        <mdb-input  label="Name" v-model="form.userName" />
        <mdb-input  label="Email" v-model="form.email" />
        <permission-select v-model="form.permission"></permission-select>

        <mdb-input  label="Changed By" v-model="form.changedBy" />
        </mdb-card-text>
      <mdb-btn color="primary" type="submit" :disabled="sending">
        <div v-if="sending">
          <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
            Sending...
        </div>
        <div v-if="!sending">Save change</div>
        </mdb-btn>
    </mdb-card-body>
    </form>
  </mdb-card>
</div>
</template>

<script>
  import organizationService from '../../services/organizationService'
  import { mdbCard, mdbCardBody, mdbCardHeader, mdbCardText, mdbBtn, mdbInput} from 'mdbvue'
  import formValidationService from '../../services/formValidationService'
  import PermissionSelect from '../HelperComponents/PermissionSelect'

  export default {
    name: 'AddOrganization',
        components: {
      mdbCard,
      mdbCardBody,
      mdbCardHeader,
      mdbCardText,
      mdbBtn,
      mdbInput,
      PermissionSelect
    },
    data: () => ({
      form : {
        userName : null,
        email: null,
        permission: 4,
        organizationId: null,
        changeDate: new Date().toJSON(),
        changedBy: null
      },
      formErrors : null,
      sending: false,
      permissionOptions : [{ text: 'SuperAdmin', value: 0},{ text: 'Admin', value:1 },{ text: 'ReadWrite', value:2}, {text:'ReadOnly', value: 3}, {text: 'NoAccess', value:4}]
    }), 
    methods: {
      submitForm(){
        this.formErrors = formValidationService.validateMemberForm(this.form);
        if (this.formErrors.isValid()){
          this.saveForm()
        }        
      },
      clearForm () {
        this.formErrors = null
        this.form.userName = null
        this.form.email = null
        this.form.permission = 4
        this.form.changeDate= new Date().toJSON()
        this.form.changedBy = null
      },
      async saveForm () {
        this.sending = true
        
        // Instead of this timeout, here you can call your API
        await organizationService.postAddOrganizationMember(this.form, this.form.organizationId)
        .then( () => {
          window.setTimeout(() => {

          }, 10000)
          this.formSaved = true
          this.sending = false
          this.clearForm()
        })
        .catch( error => {
          console.log(error)
        });
        this.$router.push({ name: 'orgmembers', params: {id: this.form.organizationId }});
      }
    },
    created() {
        this.form.organizationId = this.$route.params.id;
    }
  }
</script>

<style scoped>
</style>
