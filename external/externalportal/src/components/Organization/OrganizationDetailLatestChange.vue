<template>
  <detail-box-component title="Latest Change">
  <mdb-row>
    <mdb-col col=2 align=right>Date:</mdb-col>
    <mdb-col>
      {{ prettyDate }}
    </mdb-col>
  </mdb-row>
    <mdb-row>
    <mdb-col col=2 align=right>By:</mdb-col>
    <mdb-col>
      {{ changedBy }}
    </mdb-col>
  </mdb-row>
  </detail-box-component>
</template>

<script>
  import { mdbRow, mdbCol} from 'mdbvue';
import DetailBoxComponent from '../HelperComponents/DetailBoxComponent';
  export default {
    name: 'OrganizationDetailLatestChange',
    props: ['changeDate', 'changedBy'],
    components: {
      mdbRow, mdbCol,
        DetailBoxComponent
    },
    computed: {
      prettyDate: function() {
        return new Date(this.changeDate).toLocaleDateString('en-GB',{
          weekday: 'short',
          year: 'numeric',
          month: 'short',
          day: 'numeric',
          hour: '2-digit',
          minute: '2-digit'
        })
      }
    }
  }

</script>
