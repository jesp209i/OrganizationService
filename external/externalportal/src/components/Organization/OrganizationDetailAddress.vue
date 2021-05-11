<template>
  <detail-box-component title="Address">
    <mdb-row>
      <mdb-col col=1></mdb-col>
      <mdb-col>
        <mdb-row><mdb-col>
            {{street}}
        </mdb-col></mdb-row>
        <mdb-row  v-if="streetExtended"><mdb-col>
          {{streetExtended}}
        </mdb-col></mdb-row>
        <mdb-row><mdb-col>
          {{postalCode}}
        </mdb-col></mdb-row>
        <mdb-row><mdb-col>
          {{city}}
        </mdb-col></mdb-row>
        <mdb-row><mdb-col>
          {{country}}
        </mdb-col></mdb-row>
      </mdb-col>
    </mdb-row>
    <template v-slot:actions >
        <mdb-btn size="sm" color="primary" v-on:click="$emit('toggleAddress')">Change Address</mdb-btn>
    </template>
  
  </detail-box-component>
</template>

<script>
import DetailBoxComponent from '../HelperComponents/DetailBoxComponent'
  import { mdbRow, mdbCol, mdbBtn} from 'mdbvue';

  export default {
    name: 'OrganizationDetailAddress',
    props: ['street', 'streetExtended','postalCode', 'city', 'country'],
    components: {
      mdbRow, mdbCol, mdbBtn, DetailBoxComponent
        
    },
  }

</script>
<style scoped>
.col- {
  margin:20px;
}
</style>