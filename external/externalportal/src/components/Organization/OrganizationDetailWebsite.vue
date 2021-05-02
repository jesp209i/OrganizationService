<template>
  <mdb-card class="w-75 mb-4">
    <mdb-card-header>Website</mdb-card-header>
    <mdb-card-body>
      <mdb-card-text>
        {{ website }}      
        </mdb-card-text>
      <mdb-btn color="primary" v-on:click="$emit('toggleWebsite')">Edit VAT number</mdb-btn>
    </mdb-card-body>
  </mdb-card>
</template>

<script>
import { mdbCard, mdbCardBody, mdbCardHeader, mdbCardText, mdbBtn} from 'mdbvue';
  export default {
    name: 'OrganizationDetailWebsite',
    props: ['website'],
        components: {
      mdbCard,
      mdbCardBody,
      mdbCardHeader,
      mdbCardText,
      mdbBtn
    },
  }
</script>