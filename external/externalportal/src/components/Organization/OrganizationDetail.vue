<template>
  <mdb-container>
    <mdb-row>
      <mdb-col>
    <h2>Organization Details</h2>
    <div class="spinner-border" role="status" v-if="loaded === false">
      <span class="sr-only">Loading...</span>
    </div>
    <mdb-container v-if="loaded">
      
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

<div>
  <mdb-row>
    <mdb-col><strong>Latest change:</strong></mdb-col>
    </mdb-row>
     <mdb-row>
    <mdb-col col=1></mdb-col>
    <mdb-col col=3>{{ organization.changeDate }}</mdb-col>
     </mdb-row>
      <mdb-row>
        <mdb-col col=1></mdb-col>
    <mdb-col col=3>
            {{ organization.changedBy }}</mdb-col></mdb-row>
</div>      

    </mdb-container>
      </mdb-col>
    </mdb-row>
  </mdb-container>
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
  import { mdbContainer, mdbRow, mdbCol} from 'mdbvue';

  export default {
    name: 'OrganizationDetail',
    components: {
 mdbContainer, mdbRow, mdbCol
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
.col{
  margin: 20px;
}
</style>
