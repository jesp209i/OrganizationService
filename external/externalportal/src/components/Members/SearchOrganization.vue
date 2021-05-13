<template>
  <mdb-container>
    <mdb-row>
      <mdb-col>
        <h2>Search Organization by Member Email</h2> 
        <p>By searching on a Members email you can see which organizations they are part of</p>
      </mdb-col>
    </mdb-row>
    
      <mdb-row class="justify-content-md-center">
        <mdb-col lg="6">
          <mdb-input label="Email" v-model="email">
            <mdb-btn color="primary" type="submit" :disabled="sending || email.length < 1" group slot="append" @click="submitForm">
              <div v-if="sending">
                <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                  Searching...
              </div>
              <div v-if="!sending">Search</div>
            </mdb-btn>
          </mdb-input>
          <div :class="['error', {'hidden' : emailError === false}]">Bad format on Email</div>
        </mdb-col>
      </mdb-row>
    <loading-screen :loading="sending" :error="error" />
    <organization-list-component :list="list" v-if="loaded === true"></organization-list-component>
  </mdb-container> 
</template>
<script>
import {mdbBtn, mdbInput, mdbContainer, mdbRow, mdbCol} from 'mdbvue'
import service from '../../services/organizationService'
import OrganizationListComponent from '../HelperComponents/OrganizationListComponent'
import LoadingScreen from '../HelperComponents/LoadingScreen'

export default {
  name: "SearchOrganization",
  components: {
    mdbContainer,
    mdbRow,
    mdbCol,
    mdbBtn,
    mdbInput,
    OrganizationListComponent,
    LoadingScreen
  },
  data: () => ({
    email : '',
    sending : false,
    loaded: false,
    list: null,
    emailError : false,
    error: false
  }),
  methods: {
    async submitForm(){
      this.sending = true
      this.loaded = false
      this.emailError = false
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
        if (err.response.data.status >= 500)
          this.error = true
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
  font-size: 150%;
  font-weight: 900;
  text-align:center;
}
</style>
