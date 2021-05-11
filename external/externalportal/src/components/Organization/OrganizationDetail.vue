<template>
  <mdb-container>
    <mdb-row>
      <mdb-col style="margin:20px;">
    <h2>Organization Details</h2>
    </mdb-col></mdb-row>

    <div class="spinner-border" role="status" v-if="loaded === false">
      <span class="sr-only">Loading...</span>
    </div>
    <div v-if="loaded">
      <mdb-row>
        <mdb-col>
          <mdb-row>
            <mdb-col>
              <organization-detail-name 
                :name="organization.name" />
            </mdb-col>
          </mdb-row>
          <mdb-row>
            <mdb-col>
            <component 
              v-bind:is="orgDetailAddress" 
              :street="organization.street" 
              :streetExtended="organization.streetExtended"
              :postalCode="organization.postalCode"
              :city="organization.city"
              :country="organization.country" 
              :organizationId="orgId"
              v-on:toggleAddress="toggleAddress" />
            </mdb-col>
          </mdb-row>
          
        </mdb-col>
        <mdb-col>
          <mdb-row><mdb-col>
            <component 
              v-bind:is="orgDetailVatNumber" 
              :vatNumber="organization.vatNumber" 
              :organizationId="orgId"
              v-on:toggleVatNumber="toggleVatNumber" />
          </mdb-col></mdb-row>
          <mdb-row><mdb-col>
            <component 
              v-bind:is="orgDetailWebsite" 
              :website="organization.website"
              :organizationId="orgId"
              v-on:toggleWebsite="toggleWebsite" />
          </mdb-col></mdb-row>
          <mdb-row><mdb-col>
            <organization-detail-latest-change
              :changeDate="organization.changeDate"
              :changedBy="organization.changedBy" /> 
          </mdb-col></mdb-row>
        </mdb-col>
      </mdb-row>
    </div>
  </mdb-container>
</template>

<script>
  import service from '../../services/organizationService'
  import OrganizationDetailName from './OrganizationDetailName'
  import OrganizationDetailAddress from './OrganizationDetailAddress'
  import OrganizationDetailWebsite from './OrganizationDetailWebsite'
  import OrganizationDetailVatNumber from './OrganizationDetailVatNumber'
  import ChangeAddress from './Change/Address'
  import ChangeVatNumber from './Change/VatNumber'
  import ChangeWebsite from './Change/Website'
  import OrganizationDetailLatestChange from './OrganizationDetailLatestChange'
  import { mdbContainer, mdbRow, mdbCol} from 'mdbvue';



  export default {
    name: 'OrganizationDetail',
    components: {
 mdbContainer, mdbRow, mdbCol, OrganizationDetailName, OrganizationDetailLatestChange
        
        
    },
    data: () => ({
      loaded: false,
      organization: {},
      orgId : null,
      orgDetailName : OrganizationDetailName,
      orgDetailAddress : OrganizationDetailAddress,
      orgDetailWebsite : OrganizationDetailWebsite,
      orgDetailVatNumber : OrganizationDetailVatNumber,
      orgDetailChange : OrganizationDetailLatestChange
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

