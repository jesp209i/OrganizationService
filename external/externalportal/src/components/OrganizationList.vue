<template>
  <div>
    <h2>List</h2>
    <div class="spinner-border" role="status" v-if="loaded === false">
      <span class="sr-only">Loading...</span>
    </div>
    <mdb-tbl v-if="loaded === true">
      <mdb-tbl-head>
      <tr>
        
        <th>Name</th>
        <th>VAT Number</th>
        <th>Country</th>
        
      </tr>
      </mdb-tbl-head>
      <mdb-tbl-body>
      <tr v-for="item in list" :key="item.id" @click="detail(item.id)" class="clickable">
        
        <td>{{ item.name }}</td>
        <td>{{ item.vatNumber }}</td>
        <td>{{ item.country }}</td>
        
      </tr>
      </mdb-tbl-body>
    </mdb-tbl>
  </div>
</template>

<script>
  import service from '../services/organizationService'
  import { mdbTbl, mdbTblHead, mdbTblBody } from 'mdbvue';
  export default {
    name: 'OrganizationList',
    components: {
      mdbTbl,
      mdbTblHead,
      mdbTblBody
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
      detail(id){
        this.$router.push({ path: `organization/${id}/info` })
      }
    },
    created() {
      this.getOrganizations()
    }
  }
</script>

<style scoped>
.clickable {
  cursor: pointer;
}
.clickable:hover {
  background-color: #CCC;
  color: white;
  font-weight: 900;
}

</style>
