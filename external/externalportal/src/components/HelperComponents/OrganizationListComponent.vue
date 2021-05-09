<template>
  <mdb-tbl>
    <mdb-tbl-head>
    <tr>
      
      <th>Name</th>
      <th>VAT Number</th>
      <th>Country</th>
      
    </tr>
    </mdb-tbl-head>
    <mdb-tbl-body v-if="moreThanZero === true">
    <tr v-for="item in list" :key="item.id" @click="detail(item.id)" class="clickable">
      
      <td>{{ item.name }}</td>
      <td>{{ item.vatNumber }}</td>
      <td>{{ item.country }}</td>
      
    </tr>
    </mdb-tbl-body>
    <mdb-tbl-body v-if="moreThanZero === false">
      <tr>
        <td colspan="3">No results :(</td>
      </tr>
    </mdb-tbl-body>
  </mdb-tbl>
</template>
<script>
import { mdbTbl, mdbTblHead, mdbTblBody } from 'mdbvue'

export default {
  name: 'OrganizationListComponent',
  props: ['list'],
  components: {
    mdbTbl,
    mdbTblHead,
    mdbTblBody
  },
  methods: {
    detail(orgId){
      this.$router.push({ name: 'orginfo', params: { id: orgId}})
    }
  },
  computed: {
    moreThanZero: function(){
      return this.list.length > 0
    }
  }
}
</script>
<style scoped>
.clickable {
  cursor: pointer;
}
.clickable:hover {
  background-color: #CCC;
  color: white;
  font-weight: 900;
}

</style>

