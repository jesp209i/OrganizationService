<template>
  <mdb-container>
    <mdb-row>
      <mdb-col>
    <h2>Member List</h2>
    <div class="spinner-border" role="status" v-if="loaded === false">
      <span class="sr-only">Loading...</span>
    </div>
    <mdb-container v-if="loaded === true">

      <mdb-row>
        <mdb-col>Email</mdb-col>
        <mdb-col>Name</mdb-col>
        <mdb-col>Permission</mdb-col>
        <mdb-col></mdb-col>
      </mdb-row>
      <div v-for="item in list" :key="item.id">
      <div  >
      <mdb-row >
        <mdb-col>{{ item.email }}</mdb-col>
        <mdb-col>{{ item.userName }}</mdb-col>
        <mdb-col>{{ permissionTexts[item.permission] }}</mdb-col>
        <mdb-col>
          <mdb-btn @click="toggle(item.email)" size="sm">
            <span v-if="show.includes(item.email) === false"><mdb-icon icon="edit" class="mr-1"/> Change</span>
            <span v-if="show.includes(item.email) === true"><mdb-icon icon="cancel" class="mr-1"/> Close</span>
          </mdb-btn>
        </mdb-col>
        
      </mdb-row>
      </div>
      <mdb-row v-if="show.includes(item.email)" style="border-bottom: 2px solid #CCC;">
        <mdb-col >
          <permission-select :permission="item.permission" v-model="item.permission"></permission-select>
          </mdb-col><mdb-col>
          <mdb-input  label="Changed By" v-model="changedBy">
          <mdb-btn @click="updatePermission(item)" group slot="append" :disabled="changedBy.length < 1">Update permission</mdb-btn>
          </mdb-input>
        </mdb-col>
      </mdb-row>
      </div>
    </mdb-container>
      </mdb-col>
    </mdb-row>
  </mdb-container>
</template>

<script>
  import service from '../../services/organizationService'
  import PermissionSelect from '../HelperComponents/PermissionSelect'
  import { mdbContainer, mdbRow, mdbCol, mdbBtn, mdbInput, mdbIcon } from 'mdbvue';

  export default {
    name: 'MemberList',
    components: {
      mdbContainer, mdbRow, mdbCol, mdbBtn, mdbInput, mdbIcon ,
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
