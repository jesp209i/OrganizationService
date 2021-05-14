<template>
<div>
  <mdb-tbl v-if="moreThanZero === true">
    <mdb-tbl-head>
    <tr>
      
      <th>Name</th>
      <th>VAT Number</th>
      <th>Country</th>
      
    </tr>
    </mdb-tbl-head>
    <mdb-tbl-body>
    <tr v-for="item in list" :key="item.id" @click="detail(item.id)" class="clickable">
      
      <td>{{ item.name }}</td>
      <td>{{ item.vatNumber }}</td>
      <td>{{ item.country }}</td>
      
    </tr>
    </mdb-tbl-body>
  </mdb-tbl>

  <div v-if="moreThanZero === false" class="no-results">
    No Organizations Found
  </div>
</div>
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
.no-results{
  font-size: 150%;
  font-weight: 900;
  color: #f93;
  text-align: center;
}

</style>

