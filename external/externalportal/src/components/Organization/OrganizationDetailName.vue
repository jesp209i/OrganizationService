<template>
<detail-box-component title="Name">
  <mdb-row>
    <mdb-col col=1></mdb-col>
    <mdb-col>
      {{ name }}
    </mdb-col>
  </mdb-row>
</detail-box-component>

</template>

<script>
import DetailBoxComponent from '../HelperComponents/DetailBoxComponent'
  import { mdbRow, mdbCol} from 'mdbvue';
  export default {
    name: 'OrganizationDetailName',
    props: ['name'],
    components: {
      mdbRow, mdbCol, DetailBoxComponent
    },
  }

</script>
