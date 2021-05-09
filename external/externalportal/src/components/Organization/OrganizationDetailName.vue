<template>
  <div>
  <mdb-row>
    <mdb-col col=1>
      <strong>Name</strong>
    </mdb-col>
  </mdb-row>
  <mdb-row>
    <mdb-col col=1></mdb-col>
    <mdb-col>
      {{ name }}
    </mdb-col>
  </mdb-row>
  </div>
</template>

<script>
  import { mdbRow, mdbCol} from 'mdbvue';
  export default {
    name: 'OrganizationDetailName',
    props: ['name'],
    components: {
      mdbRow, mdbCol
    },
  }

</script>
