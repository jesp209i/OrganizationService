<template>
  <mdb-container>
    <loading-screen :loading="!loaded"></loading-screen>
    <mdb-row v-if="loaded === true">
      <mdb-col>
    <h2>Organization List</h2>
    <organization-list-component :list="list" ></organization-list-component>
      </mdb-col>
    </mdb-row>
    
  </mdb-container>
</template>

<script>
  import service from '../services/organizationService'
  import { mdbContainer, mdbRow, mdbCol } from 'mdbvue'
  import LoadingScreen from './HelperComponents/LoadingScreen'
  import OrganizationListComponent from './HelperComponents/OrganizationListComponent'
  export default {
    name: 'OrganizationList',
    components: {
      OrganizationListComponent, mdbContainer, mdbRow, mdbCol, LoadingScreen
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