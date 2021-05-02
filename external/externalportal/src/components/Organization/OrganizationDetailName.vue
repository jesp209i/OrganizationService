<template>
  <mdb-card class="w-75 mb-4">
    <mdb-card-header>Name</mdb-card-header>
    <mdb-card-body>
      <mdb-card-text>{{ name }}</mdb-card-text>
    </mdb-card-body>
  </mdb-card>
</template>

<script>
  import { mdbCard, mdbCardHeader, mdbCardBody, mdbCardText} from 'mdbvue';
  export default {
    name: 'OrganizationDetailName',
    props: ['name'],
    components: {
      mdbCard,
      mdbCardHeader,
      mdbCardBody,
      mdbCardText
    },
  }

</script>
