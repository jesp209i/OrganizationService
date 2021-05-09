<template>
  <mdb-container>
    <mdb-row>
      <mdb-col>
        <h2>Find Organization</h2> 
        <p>By searching on a Members email you can see which organizations they are part of</p>
      </mdb-col>
    </mdb-row>
    <form @submit.prevent="submitForm">
      <mdb-row>
        <mdb-col col="7">
          <mdb-input label="Email" v-model="email">
            <mdb-btn color="primary" type="submit" :disabled="sending" group slot="append">
              <div v-if="sending">
                <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                  Sending...
              </div>
              <div v-if="!sending">Search</div>
            </mdb-btn>
          </mdb-input>
        </mdb-col>
      </mdb-row>
    </form>
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
    list: null
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
          
        })
      .catch(error => console.log(error))
    }
  }
}
</script>
