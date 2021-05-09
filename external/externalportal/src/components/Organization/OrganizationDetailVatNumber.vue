<template>
<div>
  <mdb-row>
    <mdb-col><strong>VAT Number</strong></mdb-col>
    </mdb-row>
     <mdb-row>
    <mdb-col col=1></mdb-col>
    <mdb-col col=3>
        {{vatNumber}} 
    </mdb-col>
    <mdb-col>
      <mdb-btn color="primary" v-on:click="$emit('toggleVatNumber')">Edit VAT number</mdb-btn>
      </mdb-col>
    
  </mdb-row>
  </div>
</template>
<script>
  import { mdbCol, mdbRow, mdbBtn} from 'mdbvue';
  export default {
    name: 'OrganizationDetail',
    props: ['vatNumber'],
    components: {
      mdbCol,
      mdbRow,
      mdbBtn
    },
  }

</script>