<template>
<detail-box-component title="Website">

  <mdb-row>
    <mdb-col col=1></mdb-col>
    <mdb-col col=3>
        {{ website }}      
    </mdb-col>
  </mdb-row>
  <template v-slot:actions>
    <mdb-btn color="primary" size="sm" v-on:click="$emit('toggleWebsite')">Change Website</mdb-btn>  
  </template>
</detail-box-component>
</template>

<script>
import { mdbCol, mdbRow, mdbBtn} from 'mdbvue';
import DetailBoxComponent from '../HelperComponents/DetailBoxComponent.vue';
  export default {
    name: 'OrganizationDetailWebsite',
    props: ['website'],
    components: {
      mdbCol,
      mdbRow,
      mdbBtn,
        DetailBoxComponent
    },
  }
</script>
