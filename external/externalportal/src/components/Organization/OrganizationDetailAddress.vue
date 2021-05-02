<template>
  <mdb-card class="w-75 mb-4">
    <mdb-card-header>Address</mdb-card-header>
    <mdb-card-body>
      <mdb-card-text>
        {{street}} <br />
        {{streetExtended}} <br />
        {{postalCode}}<br />
        {{city}}<br />
        {{country}}
      </mdb-card-text>
      <mdb-btn color="primary" v-on:click="$emit('toggleAddress')">Edit Address</mdb-btn>
    </mdb-card-body>
  </mdb-card>
</template>

<script>
  import { mdbCard, mdbCardBody, mdbCardHeader, mdbCardText, mdbBtn} from 'mdbvue';
  export default {
    name: 'OrganizationDetailAddress',
    props: ['street', 'streetExtended','postalCode', 'city', 'country'],
        components: {
      mdbCard,
      mdbCardBody,
      mdbCardHeader,
      mdbCardText,
      mdbBtn
    },
  }

</script>