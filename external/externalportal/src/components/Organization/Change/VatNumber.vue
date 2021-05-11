<template>
  <detail-box-component title="Changing VAT number" changing>

    <mdb-input  label="VAT number" v-model="form.vatNumber" />
    <mdb-input  label="Changed By" v-model="form.changedBy" required ><small class="form-text text-muted">Required</small></mdb-input>
    
    <template v-slot:actions>
      <mdb-btn size="sm" color="warning" v-on:click="$emit('toggleVatNumber')">Abort</mdb-btn>
      <mdb-btn size="sm" color="primary" type="submit" :disabled="formDisabled" @click="submitForm">
        <div v-if="sending">
          <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
            Sending...
        </div>
        <div v-if="!sending">Save change</div>
      </mdb-btn>
    </template>
    
  </detail-box-component>
</template>

<script>
  import organizationService from '../../../services/organizationService'
  import {   mdbBtn, mdbInput} from 'mdbvue'
  import formValidationService from '../../../services/formValidationService'
  import DetailBoxComponent from '../../HelperComponents/DetailBoxComponent'

  export default {
    name: 'ChangeName',
    props: ['vatNumber', 'organizationId'],
    components: {
      mdbBtn,
      mdbInput,
        DetailBoxComponent
    },
    data: () => ({
      form : {
        vatNumber: null,
        changeDate: new Date().toJSON(),
        changedBy: ''
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
      async saveForm () {
        this.sending = true
        
        // Instead of this timeout, here you can call your API
        await organizationService.postUpdateOrganizationVatNumber(this.form, this.organizationId)
        .then( () => {
          window.setTimeout(() => {

          }, 5000)
          this.formSaved = true
          this.sending = false
        })
        .catch( error => {
          console.log(error)
        });
        this.$router.go(0)
      }
    },
    created(){
      this.form.vatNumber = this.vatNumber
    },
    computed: {
      formDisabled: function(){
        if (this.sending === true || this.form.changedBy.lenght === 0)
          return true;
        return false;
      }
    }
  }
</script>

<style scoped>

</style>