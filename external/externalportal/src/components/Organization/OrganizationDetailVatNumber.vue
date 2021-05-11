<template>
  <detail-box-component title="VAT number">
    <mdb-row>
      <mdb-col col=1></mdb-col>
      <mdb-col col=3>
          {{vatNumber}} 
      </mdb-col>
    </mdb-row>
    <template v-slot:actions>
      <mdb-btn color="primary" size="sm" v-on:click="$emit('toggleVatNumber')">Change VAT number</mdb-btn>
    </template>
  </detail-box-component>
</template>
<script>
  import { mdbCol, mdbRow, mdbBtn} from 'mdbvue'
import DetailBoxComponent from '../HelperComponents/DetailBoxComponent'
  export default {
    name: 'OrganizationDetail',
    props: ['vatNumber'],
    components: {
      mdbCol,
      mdbRow,
      mdbBtn,
        DetailBoxComponent
    },
  }

</script>