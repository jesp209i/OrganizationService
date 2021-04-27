<template>
  <div>
    <h1>List</h1>
    <md-progress-bar md-mode="indeterminate" v-if="loaded === false" />
    <md-table v-if="loaded === true" md-card>
      <md-table-row>
        
        <md-table-head>Name</md-table-head>
        <md-table-head>VAT Number</md-table-head>
        <md-table-head>Website</md-table-head>
        
      </md-table-row>
      
      <md-table-row v-for="item in list" :key="item.id" @click="detail(item.id)" class="clickable">
        
        <md-table-cell>{{ item.name }}</md-table-cell>
        <md-table-cell>{{ item.vatNumber }}</md-table-cell>
        <md-table-cell>{{ item.website }}</md-table-cell>
        
      </md-table-row>
      
    </md-table>
  </div>
</template>

<script>
  import service from '../services/organizationService'

  export default {
    name: 'OrganizationList',
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
        this.$router.push({ path: `organization/${id}` })
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
</style>
