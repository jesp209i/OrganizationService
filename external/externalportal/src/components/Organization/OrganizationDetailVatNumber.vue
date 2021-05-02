<template>
  <mdb-card class="w-75 mb-4">
    <mdb-card-header>VAT Number</mdb-card-header>
    <mdb-card-body>
      <mdb-card-text>
        {{vatNumber}} 
      </mdb-card-text>
      <mdb-btn color="primary" v-on:click="$emit('toggleVatNumber')">Edit VAT number</mdb-btn>
    </mdb-card-body>
  </mdb-card>
</template>
<script>
  import { mdbCard, mdbCardBody, mdbCardHeader, mdbCardText, mdbBtn} from 'mdbvue';
  export default {
    name: 'OrganizationDetail',
    props: ['vatNumber'],
    components: {
      mdbCard,
      mdbCardBody,
      mdbCardHeader,
      mdbCardText,
      mdbBtn
    },
  }

</script>