<template>
<div>
  <h2>Create Organization</h2>
  <mdb-card class="w-75 mb-4">
    <form @submit.prevent="submitForm">
    <mdb-card-header>New Organization</mdb-card-header>
    <mdb-card-body>
      <mdb-card-text>
        <mdb-input  label="Name" v-model="form.name" />
        <mdb-input  label="Street" v-model="form.street" />
        <mdb-input  label="Street Extended" v-model="form.streetExtended" />
        <mdb-input  label="Postal Code" v-model="form.postalCode" />
        <mdb-input  label="City" v-model="form.city" />
        <mdb-input  label="Country" v-model="form.country" />
        <mdb-input  label="VAT Number" v-model="form.vatNumber" />
        <mdb-input  label="Website" v-model="form.website" />
        <mdb-input  label="Changed By" v-model="form.changedBy" />
        </mdb-card-text>
      <mdb-btn color="warning" v-on:click="$emit('toggleAddress')">Abort</mdb-btn>
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
  import organizationService from '../services/organizationService'
  import { mdbCard, mdbCardBody, mdbCardHeader, mdbCardText, mdbBtn, mdbInput} from 'mdbvue'
  import formValidationService from '../services/formValidationService'

  export default {
    name: 'AddOrganization',
        components: {
      mdbCard,
      mdbCardBody,
      mdbCardHeader,
      mdbCardText,
      mdbBtn,
      mdbInput
    },
    data: () => ({
      form : {
        name : null,
        street: null,
        streetExtended: null,
        postalCode: null,
        city: null,
        country: null,
        vatNumber: null,
        website: null,
        changeDate: new Date().toJSON(),
        changedBy: null
      },
      formErrors : null,
      sending: false
    }), 
    methods: {
      submitForm(){
        this.formErrors = formValidationService.validateCreateForm(this.form);
        if (this.formErrors.isValid()){
          this.saveForm()
        }        
      },
      clearForm () {
        this.formErrors = null
        this.form.vatNumber = null
        this.form.changeDate= new Date().toJSON()
        this.form.changedBy = null
      },
      async saveForm () {
        this.sending = true
        
        // Instead of this timeout, here you can call your API
        await organizationService.postCreateOrganization(this.form)
        .then( () => {
          window.setTimeout(() => {

          }, 1000)
          this.formSaved = true
          this.sending = false
          this.clearForm()
        })
        .catch( error => {
          console.log(error)
        });
        this.$router.go(0)
        
      }
    }
  }
</script>

<style scoped>
</style>