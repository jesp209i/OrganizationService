<template>
  <detail-box-component title="Changing Website" changing>
    
        <mdb-input  label="Website" v-model="form.website" />
        <mdb-input  label="Changed By" v-model="form.changedBy"><small class="form-text text-muted">Required</small></mdb-input>
        <template v-slot:actions>
      <mdb-btn size="sm" color="warning" v-on:click="$emit('toggleWebsite')">Abort</mdb-btn>
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
  import { mdbBtn, mdbInput} from 'mdbvue';
  import formValidationService from '../../../services/formValidationService'
import DetailBoxComponent from '../../HelperComponents/DetailBoxComponent'
  
  export default {
    name: 'ChangeWebsite',
    props: ['website', 'organizationId'],
    components: {

      mdbBtn,
      mdbInput,
        DetailBoxComponent
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
      async saveForm () {
        this.sending = true
        
        // Instead of this timeout, here you can call your API
        await organizationService.postUpdateOrganizationWebsite(this.form, this.organizationId)
        .then( () => {
          window.setTimeout(() => {

        }, 5000)
          this.formSaved = true
          this.sending = false
        })
        .catch( error => {
          console.log(error)
        });

        window.setTimeout(() => {

        }, 5000)
        this.$router.go(0)
      }
    },
    created(){
      this.form.website = this.website
    }
  }
</script>

<style scoped>

</style>