<template>
  <detail-box-component title="Changing Address" changing>
    
    
        <mdb-input  label="Street" v-model="form.street" />
        <mdb-input  label="Street Extended" v-model="form.streetExtended" />
        <mdb-input  label="Postal Code" v-model="form.postalCode" />
        <mdb-input  label="City" v-model="form.city" />
        <mdb-input  label="Country" v-model="form.country" />
        <mdb-input  label="Changed By" v-model="form.changedBy" ><small class="form-text text-muted">Required</small></mdb-input>
        <template v-slot:actions>
      <mdb-btn size="sm" color="warning" v-on:click="$emit('toggleAddress')">Abort</mdb-btn>
      <mdb-btn size="sm" color="primary" type="submit" :disabled="sending" @click="submitForm">
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
  import {mdbBtn, mdbInput} from 'mdbvue';
  import formValidationService from '../../../services/formValidationService'
import DetailBoxComponent from '../../HelperComponents/DetailBoxComponent.vue';

  export default {
    name: 'ChangeAddress',
    props: ['street','streetExtended','postalCode','city','country', 'organizationId'],
    components: {

      mdbBtn,
      mdbInput,
        DetailBoxComponent
    },
    data: () => ({
      form : {
        street: null,
        streetExtended: null,
        postalCode: null,
        city: null,
        country: null,
        changeDate: new Date().toJSON(),
        changedBy: null
      },
      formErrors : null,
      sending: false
    }),   
    methods: {
      submitForm(){
        this.formErrors = formValidationService.validateAddressForm(this.form);
        if (this.formErrors.isValid()){
          this.saveForm()
        }
      },
      async saveForm () {
        this.sending = true
        
        // Instead of this timeout, here you can call your API
        await organizationService.postUpdateOrganizationAddress(this.form, this.organizationId)
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
      this.form.street = this.street
      this.form.streetExtended = this.streetExtended
      this.form.postalCode = this.postalCode
      this.form.city = this.city
      this.form.country = this.country
    }
  }
</script>

<style scoped>

</style>