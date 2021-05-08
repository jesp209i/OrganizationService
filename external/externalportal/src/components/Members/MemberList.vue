<template>
  <div>
    <h2>Member List</h2>
    <div class="spinner-border" role="status" v-if="loaded === false">
      <span class="sr-only">Loading...</span>
    </div>
    <mdb-container v-if="loaded === true" striped hover>

      <mdb-row>
        <mdb-col>Email</mdb-col>
        <mdb-col>Name</mdb-col>
        <mdb-col>Permission</mdb-col>
        <mdb-col></mdb-col>
      </mdb-row>
      <div v-for="item in list" :key="item.id"  class="border border-dark" >
      <div  @click="toggle(item.email)">
      <mdb-row >
        <mdb-col>{{ item.email }}</mdb-col>
        <mdb-col>{{ item.userName }}</mdb-col>
        <mdb-col>{{ permissionTexts[item.permission] }}</mdb-col>
        <mdb-col class="clickable"> Change Permission</mdb-col>
        
      </mdb-row>
      </div>
      <mdb-row v-if="show.includes(item.email)">
        <mdb-col >
          <permission-select v-model="item.permission"></permission-select>
          <mdb-input  label="Changed By" v-model="changedBy" />
          <mdb-btn @click="updatePermission(item)">Update permission</mdb-btn>

        </mdb-col>
      </mdb-row>
      </div>
    </mdb-container>
  </div>
</template>

<script>
  import service from '../../services/organizationService'
  import PermissionSelect from '../HelperComponents/PermissionSelect'
  import { mdbContainer, mdbRow, mdbCol, mdbBtn, mdbInput } from 'mdbvue';

  export default {
    name: 'MemberList',
    components: {
      mdbContainer, mdbRow, mdbCol, mdbBtn, mdbInput,
      PermissionSelect
    },
    data: () => ({
      loaded: false,
      orgId : 0,
      permissionTexts : ['SuperAdmin', 'Admin', 'ReadWrite', 'ReadOnly', 'NoAccess'],
      show: [],
      changedBy : ""
    }),
    methods: {
      getAllMembers(id) {
        service.getOrganizationMembers(id)
          .then((response) => 
          {
            this.list = response.data
            this.loaded = true
          })
      },
      toggle(email){
        if (this.show.includes(email)){
          this.show.splice(this.show.indexOf(email),1);
        } else {
          this.show.push(email);
        }
        console.log(this.show);
      },
      updatePermission(user){
        this.loaded = false
        user.changedBy = this.changedBy
        service.putOrganizationMemberPermission(user,this.orgId)
        .then(() => {
          window.setTimeout(() => {
        }, 6000)
        }).catch(error =>
        console.log(error))
        this.$router.go(0)
      }
    },
    created() {
      this.orgId = this.$route.params.id;
      this.getAllMembers(this.orgId);
    }
  }
</script>

<style scoped>
.clickable {
  cursor: pointer;
}
.clickable:hover {
  font-weight: 900;
}
.col{
  margin: 20px;
}


</style>
