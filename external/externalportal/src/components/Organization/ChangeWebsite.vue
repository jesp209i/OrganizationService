<template>
  <mdb-card class="w-75 mb-4">
    <form @submit.prevent="submitForm">
    <mdb-card-header>Changing Organization Website</mdb-card-header>
    <mdb-card-body>
      <mdb-card-text>
        <mdb-input  label="Website" v-model="form.website" />
        <mdb-input  label="Changed By" v-model="form.changedBy" />
        </mdb-card-text>
      <mdb-btn color="warning" v-on:click="$emit('toggleWebsite')">Abort</mdb-btn>
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
</template>

<script>
  import organizationService from '../../services/organizationService'
  import { mdbCard, mdbCardBody, mdbCardHeader, mdbCardText, mdbBtn, mdbInput} from 'mdbvue';
  import formValidationService from '../../services/formValidationService'
  
  export default {
    name: 'ChangeWebsite',
    props: ['website', 'organizationId'],
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
        website: null,
        changeDate: new Date().toJSON(),
        changedBy: null
      },
      formErrors : null,
      formSaved : false,
      sending: false
    }),   
    methods: {
      submitForm(){
        if (this.website != this.form.website){
          this.formErrors = formValidationService.validateWebsiteForm(this.form);
          if (this.formErrors.isValid()){
            this.saveForm()
          }
        }
      },
      clearForm () {
        this.formErrors = null
        this.form.website = null
        this.form.changeDate= new Date().toJSON()
        this.form.changedBy = null
      },
      async saveForm () {
        this.sending = true
        
        // Instead of this timeout, here you can call your API
        await organizationService.postUpdateOrganizationWebsite(this.form, this.organizationId)
        .then( response => {
          console.log(response)
          this.formSaved = true
          this.sending = false
          this.clearForm()
        })
        .catch( error => {
          console.log(error)
        });

        window.setTimeout(() => {

        }, 5000)
      }
    },
    created(){
      this.form.website = this.website
    }
  }
</script>

<style scoped>

</style>