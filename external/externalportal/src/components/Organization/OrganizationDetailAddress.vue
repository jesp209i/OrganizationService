<template>
<div>
  <mdb-row>
    <mdb-col ><strong>Address</strong></mdb-col>
  </mdb-row>
  <mdb-row>
    <mdb-col col=1></mdb-col>
    <mdb-col col=3>
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
    <mdb-col>  
      <mdb-btn color="primary" v-on:click="$emit('toggleAddress')">Edit Address</mdb-btn>
    </mdb-col>
  </mdb-row>
  </div>
</template>

<script>
  import { mdbRow, mdbCol, mdbBtn} from 'mdbvue';
  export default {
    name: 'OrganizationDetailAddress',
    props: ['street', 'streetExtended','postalCode', 'city', 'country'],
    components: {
      mdbRow, mdbCol, mdbBtn
    },
  }

</script>
<style scoped>
.col- {
  margin:20px;
}
</style>