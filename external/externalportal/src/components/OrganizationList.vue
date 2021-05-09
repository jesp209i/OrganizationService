<template>
  <mdb-container>
    <mdb-row>
      <mdb-col>
    <h2>Organization List</h2>
    <div class="spinner-border" role="status" v-if="loaded === false">
      <span class="sr-only">Loading...</span>
    </div>
    <organization-list-component :list="list" v-if="loaded === true"></organization-list-component>
      </mdb-col>
    </mdb-row>
  </mdb-container>
</template>

<script>
  import service from '../services/organizationService'
  import { mdbContainer, mdbRow, mdbCol } from 'mdbvue'
  
  import OrganizationListComponent from './HelperComponents/OrganizationListComponent'
  export default {
    name: 'OrganizationList',
    components: {
      OrganizationListComponent, mdbContainer, mdbRow, mdbCol
    },
    data: () => ({
      list : [],
      loaded: false
    }),
    methods: {
      getOrganizations() {
        service.getOrganizations()
          .then((response) => 
          {
            this.list = response.data
            this.loaded = true
          })
      },
    },
    created() {
      this.getOrganizations()
    }
  }
</script>
<style scoped>
.col{
  margin: 20px;
}
</style>