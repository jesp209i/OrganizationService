<template>
  <mdb-card class="w-75 mb-4">
    <form @submit.prevent="submitForm">
    <mdb-card-header>Changing Organization VAT Number</mdb-card-header>
    <mdb-card-body>
      <mdb-card-text>
        <mdb-input  label="VAT number" v-model="form.vatNumber" />
        <mdb-input  label="Changed By" v-model="form.changedBy" />
        </mdb-card-text>
      <mdb-btn color="warning" v-on:click="$emit('toggleVatNumber')">Abort</mdb-btn>
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
    name: 'ChangeName',
    props: ['vatNumber', 'organizationId'],
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
        vatNumber: null,
        changeDate: new Date().toJSON(),
        changedBy: null
      },
      formErrors : null,
      sending: false
    }),   
    methods: {
      submitForm(){
        if (this.vatNumber != this.form.vatNumber){
          this.formErrors = formValidationService.validateVatNumberForm(this.form);
          if (this.formErrors.isValid()){
            this.saveForm()
          }
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
        await organizationService.postUpdateOrganizationVatNumber(this.form, this.organizationId)
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
    },
    created(){
      this.form.vatNumber = this.vatNumber
    }
  }
</script>

<style scoped>

</style>