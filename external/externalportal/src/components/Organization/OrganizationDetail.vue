<template>
  <div>
    <div class="spinner-border" role="status" v-if="loaded === false">
      <span class="sr-only">Loading...</span>
    </div>
    <div v-if="loaded">
      <h2>Organization Details</h2>

        <component 
          v-bind:is="orgDetailName" 
          :name="organization.name" 
          ></component>

        <component 
          v-bind:is="orgDetailAddress" 
          :street="organization.street" 
          :streetExtended="organization.streetExtended"
          :postalCode="organization.postalCode"
          :city="organization.city"
          :country="organization.country" 
          :organizationId="orgId"
          v-on:toggleAddress="toggleAddress"></component>

        <component 
          v-bind:is="orgDetailVatNumber" 
          :vatNumber="organization.vatNumber" 
          :organizationId="orgId"
          v-on:toggleVatNumber="toggleVatNumber"></component>

        <component 
          v-bind:is="orgDetailWebsite" 
          :website="organization.website"
          :organizationId="orgId"
          v-on:toggleWebsite="toggleWebsite"></component>

        <mdb-card class="w-75 mb-4">
          <mdb-card-header>Latest change</mdb-card-header>
          <mdb-list-group>
            <mdb-list-group-item>{{ organization.changeDate }}</mdb-list-group-item>
            <mdb-list-group-item>{{ organization.changedBy }}</mdb-list-group-item>
          </mdb-list-group>
        </mdb-card>  
      
    </div>
  </div>
</template>

<script>
  import service from '../../services/organizationService'
  import OrganizationDetailName from './OrganizationDetailName'
  import OrganizationDetailAddress from './OrganizationDetailAddress'
  import OrganizationDetailWebsite from './OrganizationDetailWebsite'
  import OrganizationDetailVatNumber from './OrganizationDetailVatNumber'
  import ChangeAddress from './ChangeAddress'
  import ChangeVatNumber from './ChangeVatNumber'
  import ChangeWebsite from './ChangeWebsite'
  import { mdbCard, mdbCardBody, mdbCardHeader, mdbCardTitle, mdbCardText, mdbListGroup,mdbListGroupItem } from 'mdbvue';

  export default {
    name: 'OrganizationDetail',
    components: {
      mdbCard,
      mdbCardBody,
      mdbCardHeader,
      mdbCardTitle,
      mdbCardText, 
      mdbListGroup,
      mdbListGroupItem
    },
    data: () => ({
      loaded: false,
      organization: {},
      orgId : null,
      orgDetailName : OrganizationDetailName,
      orgDetailAddress : OrganizationDetailAddress,
      orgDetailWebsite : OrganizationDetailWebsite,
      orgDetailVatNumber : OrganizationDetailVatNumber
    }),
    methods :{
      toggleWebsite: function (){
        console.log("clicked")
        if (this.orgDetailWebsite === OrganizationDetailWebsite){
          this.orgDetailWebsite = ChangeWebsite
        } else {
          this.orgDetailWebsite = OrganizationDetailWebsite
        }
      },
      toggleAddress: function (){
        if (this.orgDetailAddress === OrganizationDetailAddress){
          this.orgDetailAddress = ChangeAddress
        } else {
          this.orgDetailAddress = OrganizationDetailAddress
        }
      },
      toggleVatNumber: function (){
        if (this.orgDetailVatNumber === OrganizationDetailVatNumber){
          this.orgDetailVatNumber = ChangeVatNumber
        } else {
          this.orgDetailVatNumber = OrganizationDetailVatNumber
        }
      }
    },
    async created(){
      await service.getOrganization(this.$route.params.id)
      .then(response => 
        { 
          this.organization = response.data
          this.orgId = response.data.id
        })
      this.loaded = true
    }
  }
</script>

<style scoped>

</style>
