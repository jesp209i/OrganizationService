<template>
<div>
  <mdb-row>
    <mdb-col><strong>Website</strong></mdb-col>
    </mdb-row>
     <mdb-row>
    <mdb-col col=1></mdb-col>
    <mdb-col col=3>
        {{ website }}      
    </mdb-col>
    <mdb-col>
      <mdb-btn color="primary" v-on:click="$emit('toggleWebsite')">Edit Website</mdb-btn>
    </mdb-col>
  </mdb-row>
  </div>
</template>

<script>
import { mdbCol, mdbRow, mdbBtn} from 'mdbvue';
  export default {
    name: 'OrganizationDetailWebsite',
    props: ['website'],
    components: {
      mdbCol,
      mdbRow,
      mdbBtn
    },
  }
</script>