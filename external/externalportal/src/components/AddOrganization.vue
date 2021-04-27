<template>
  <div>
    <form class="md-layout" @submit.prevent="validateForm">
      <md-card class="md-layout-item md-size-50 md-small-size-100">
        <md-card-header>
          <div class="md-title">Add Organization</div>
        </md-card-header>
        <md-card-content>
          
          <div class="md-layout-item md-small-size-100">
            <md-field :class="getValidationClass('name')">
              <label for="name">Organization Name</label>
              <md-input name="name" id="name" v-model="form.name" :disabled="sending" />
              <span class="md-error" v-if="!$v.form.name.required">The name is required</span>
              <span class="md-error" v-else-if="!$v.form.name.minlength">Invalid name</span>
            </md-field>
          </div>

          <div class="md-layout-item md-small-size-100">
            <md-field :class="getValidationClass('street')">
              <label for="street">Street</label>
              <md-input name="street" id="street" v-model="form.street" :disabled="sending" />
              <span class="md-error" v-if="!$v.form.street.required">The street is required</span>
              <span class="md-error" v-else-if="!$v.form.street.minlength">Invalid street</span>
            </md-field>
          </div>

          <div class="md-layout-item md-small-size-100">
            <md-field :class="getValidationClass('streetExtended')">
              <label for="streetExtended">Street Extended</label>
              <md-input name="streetExtended" id="streetExtended" v-model="form.streetExtended" :disabled="sending" />
            </md-field>
          </div>
          

          <div class="md-layout md-gutter">
            <div class="md-layout-item md-small-size-100">
              <md-field :class="getValidationClass('postalCode')">
                <label for="postalCode">Postal Code</label>
                <md-input name="postalCode" id="postalCode" v-model="form.postalCode"  :disabled="sending" />
                <span class="md-error" v-if="!$v.form.postalCode.required">The Postal Code is required</span>
                <span class="md-error" v-else-if="!$v.form.postalCode.minlength">Invalid Postal Code</span>
              </md-field>
            </div>

            <div class="md-layout-item md-small-size-100">
              <md-field :class="getValidationClass('city')">
                <label for="city">City</label>
                <md-input  id="city" name="city" v-model="form.city" :disabled="sending" />
                <span class="md-error" v-if="!$v.form.city.required">The city is required</span>
                <span class="md-error" v-else-if="!$v.form.city.minlength">Invalid city</span>
              </md-field>
            </div>
          </div>

          <md-field :class="getValidationClass('country')">
            <label for="country">Country</label>
            <md-input type="country" name="country" id="country" v-model="form.country" :disabled="sending" />
            <span class="md-error" v-if="!$v.form.country.required">The country is required</span>
            <span class="md-error" v-else-if="!$v.form.country.minLength">Invalid country</span>
          </md-field>
          
          <md-field :class="getValidationClass('vatNumber')">
            <label for="vatNumber">VAT Number</label>
            <md-input type="vatNumber" name="vatNumber" id="vatNumber" v-model="form.vatNumber" :disabled="sending" />
          </md-field>

          <md-field :class="getValidationClass('website')">
            <label for="website">Website</label>
            <md-input type="website" name="website" id="website" v-model="form.website" :disabled="sending" />
          </md-field>

          <md-field :class="getValidationClass('changedBy')">
            <label for="changedBy">Changed By</label>
            <md-input type="changedBy" name="changedBy" id="changedBy" v-model="form.changedBy" :disabled="sending" />
            <span class="md-error" v-if="!$v.form.changedBy.required">The Changed By is required</span>
            <span class="md-error" v-else-if="!$v.form.changedBy.minLength">Invalid Changed By</span>
          </md-field>
        </md-card-content>

        <md-progress-bar md-mode="indeterminate" v-if="sending" />

        <md-card-actions>
          <md-button type="submit" class="md-primary" :disabled="sending">Create Organization</md-button>
        </md-card-actions>
      </md-card>

      <md-snackbar :md-active.sync="formSaved">The user {{ lastUser }} was saved with success!</md-snackbar>
    </form>
  </div>
</template>

<script>
  import organizationService from '../services/organizationService'
  import { validationMixin } from 'vuelidate'
  import {
    required,
    minLength
  } from 'vuelidate/lib/validators'
  export default {
    name: 'AddOrganization',
    mixins: [validationMixin],
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
        changeDate: Date(),
        changedBy: null
      },
      formSaved : false,
      sending: false,
      lastUser: null
    }),
    validations: {
      form: {
        name: {
          required,
          minLength: minLength(3)
        },
        street: {
          required,
          minLength: minLength(3)
        },
        postalCode: {
          required,
          minLength: minLength(3)
        },
        city: {
          required,
          minLength: minLength(2)
        },
        country: {
          required,
          minLength: minLength(2)
        },
        changedBy: {
          required,
          minLength: minLength(3)
        }
      }
    },    
    methods: {
      getValidationClass (fieldName) {
        const field = this.$v.form[fieldName]

        if (field) {
          return {
            'md-invalid': field.$invalid && field.$dirty
          }
        }
      },
      clearForm () {
        this.$v.$reset()
        this.form.name = null
        this.form.street = null
        this.form.streetExtended = null
        this.form.city = null
        this.form.postalCode = null
        this.form.country = null
        this.form.vatNumber = null
        this.form.website = null
        this.form.changeDate= Date()
        this.form.changedBy = null
      },
      saveForm () {
        this.sending = true
        
        // Instead of this timeout, here you can call your API
        organizationService.postCreateOrganization(this.form);

        window.setTimeout(() => {
          this.lastUser = `${this.form.name}`
          this.formSaved = true
          this.sending = false
          this.clearForm()
        }, 5000)
      },
      validateForm () {
        this.$v.$touch()
        if (!this.$v.$invalid) {
          this.saveForm()
        }
      }
    }
  }
</script>

<style scoped>
  .md-progress-bar {
    position: absolute;
    top: 0;
    right: 0;
    left: 0;
  }
</style>