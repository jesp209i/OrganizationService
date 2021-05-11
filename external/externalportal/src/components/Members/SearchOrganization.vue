<template>
  <mdb-container>
    <mdb-row>
      <mdb-col>
        <h2>Find Organization</h2> 
        <p>By searching on a Members email you can see which organizations they are part of</p>
      </mdb-col>
    </mdb-row>
    
      <mdb-row>
        <mdb-col col="6">
          <mdb-input label="Email" v-model="email">
            <mdb-btn color="primary" type="submit" :disabled="sending" group slot="append" @click="submitForm">
              <div v-if="sending">
                <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                  Sending...
              </div>
              <div v-if="!sending">Search</div>
            </mdb-btn>
          </mdb-input>
          <small :class="['error', {'hidden' : emailError === false}]">Bad email :(</small>
        </mdb-col>
      </mdb-row>
    
    <organization-list-component :list="list" v-if="loaded === true"></organization-list-component>
  </mdb-container> 
</template>
<script>
import {mdbBtn, mdbInput, mdbContainer, mdbRow, mdbCol} from 'mdbvue'
import service from '../../services/organizationService'
import OrganizationListComponent from '../HelperComponents/OrganizationListComponent'

export default {
  name: "SearchOrganization",
  components: {
    mdbContainer,
    mdbRow,
    mdbCol,
    mdbBtn,
    mdbInput,
    OrganizationListComponent
  },
  data: () => ({
    email : null,
    sending : false,
    loaded: false,
    list: null,
    emailError : false
  }),
  methods: {
    async submitForm(){
      this.sending = true
      this.loaded = false
      await service.postSearchOrganizations(this.email)
      .then(response => 
        {
          this.list = response.data
          this.sending = false;
          this.loaded = true
          this.emailError = false
          
        })
      .catch(err =>
      { 
        if (err.response.data.status === 400)
          this.emailError = true;
        this.sending = false;
      })
    }
  }
}
</script>
<style scoped>
.col{
  margin:20px;
}
.hidden {
  display : none;
}
.error {
  color: red;
}
</style>
