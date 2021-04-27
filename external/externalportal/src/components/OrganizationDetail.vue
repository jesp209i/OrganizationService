<template>
  <div>
    <md-progress-spinner :md-diameter="100" :md-stroke="10" md-mode="indeterminate" v-if="!loaded"></md-progress-spinner>
<div class="viewport" v-if="loaded">
      <md-toolbar :md-elevation="0">
        <span class="md-title">Organization Details</span>
      </md-toolbar>

      <md-list>
        <md-subheader>Organization Name</md-subheader>

        <md-list-item :to="'/organization/'+ orgId + '/changeName'">
          <md-icon class="md-primary">account_balance</md-icon>
          <div class="md-list-item-text">
            <span>{{ organization.name }}</span>
            <span>Organization Name</span>
          </div>
        </md-list-item>
        <md-divider></md-divider>
        <md-subheader>Address</md-subheader>

        <md-list-item :to="'/organization/'+ orgId + '/changeAddress'">
          <md-icon class="md-primary">home</md-icon>
          <div class="md-list-item-text">
            <span>{{ organization.street }}</span>
            <span>{{ organization.streetExtended }}</span>
            <span>{{ organization.postalCode }}</span>
            <span>{{ organization.city }}</span>
            <span>{{ organization.country }}</span>
          </div>
        </md-list-item>

        <md-divider></md-divider>
        <md-subheader>VAT Number</md-subheader>

        <md-list-item :to="'/organization/'+ orgId + '/changeVatNumber'">
          <md-icon class="md-primary">account_balance</md-icon>

          <div class="md-list-item-text">
            <span>{{ organization.vatNumber }}</span>
            
          </div>
        </md-list-item>

        <md-divider></md-divider>
        <md-subheader>Website</md-subheader>
        <md-list-item :to="'/organization/'+ orgId + '/changeWebsite'">
          <md-icon class="md-primary">web</md-icon>
          <div class="md-list-item-text">
            <span>{{ organization.website }}</span>
          </div>
        </md-list-item>

        <md-divider></md-divider>
        <md-subheader>Latest change</md-subheader>
        <md-list-item>
          <md-icon class="md-primary">code</md-icon>
          <div class="md-list-item-text">
            <span>Latest change at {{ organization.changeDate }} by {{ organization.changedBy }}</span>
          </div>
        </md-list-item>
      </md-list>
    </div>
  </div>
</template>

<script>
  import service from '../services/organizationService'

  export default {
    name: 'OrganizationDetail',
    data: () => ({
      loaded: false,
      organization: {},
      orgId : null
    }),
    async created(){
      await service.getOrganization(this.$route.params.id)
      .then(response => 
        { 
          console.log(response)
          this.organization = response.data
          this.orgId = response.data.id
        })
      this.loaded = true
    }
  }
</script>

<style scoped>
.viewport {
  width: calc(100% - 48px);
}
</style>
