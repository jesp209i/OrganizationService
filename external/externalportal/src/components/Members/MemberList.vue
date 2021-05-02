<template>
  <div>
    <h2>Member List</h2>
    <div class="spinner-border" role="status" v-if="loaded === false">
      <span class="sr-only">Loading...</span>
    </div>
    <mdb-tbl v-if="loaded === true">
      <mdb-tbl-head>
      <tr>
        <th>Email</th>
        <th>Name</th>
      </tr>
      </mdb-tbl-head>
      <mdb-tbl-body>
      <tr v-for="item in list" :key="item.id" @click="detail(item.email)" class="clickable">
        <td>{{ item.email }}</td>
        <td>{{ item.name }}</td>
      </tr>
      </mdb-tbl-body>
    </mdb-tbl>
  </div>
</template>

<script>
  import service from '../services/organizationService'
  import { mdbTbl, mdbTblHead, mdbTblBody } from 'mdbvue';
  export default {
    name: 'MemberList',
    components: {
      mdbTbl,
      mdbTblHead,
      mdbTblBody
    },
    data: () => ({
      list : [],
      loaded: false
    }),
    methods: {
      getAllMembers() {
        service.getAllMembers()
          .then((response) => 
          {
            this.list = response.data
            this.loaded = true
          })
      },
      detail(email){
        this.$router.push({ path: `members/${email}` })
      }
    },
    created() {
      this.getAllMembers()
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
