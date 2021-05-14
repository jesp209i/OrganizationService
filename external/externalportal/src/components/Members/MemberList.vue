<template>
  <mdb-container>
    <loading-screen :loading="loaded === false" :error="error"></loading-screen>
    <mdb-row  v-if="loaded === true">
      <mdb-col>
    <h2>Member List</h2>
    <mdb-container>

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
          </mdb-col>
          <mdb-col>
            <mdb-input  label="Changed By" v-model="changedBy">
            <mdb-btn @click="updatePermission(item)" group slot="append" :disabled="changedBy.length < 1 || sending == true">
              <div v-if="sending">
                <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                Updating...
              </div><div v-if="sending === false">
              Update permission</div>
            </mdb-btn>
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
  import LoadingScreen from '../HelperComponents/LoadingScreen'

  export default {
    name: 'MemberList',
    components: {
      mdbContainer, mdbRow, mdbCol, mdbBtn, mdbInput, mdbIcon ,
      PermissionSelect, LoadingScreen
    },
    data: () => ({
      loaded: false,
      orgId : 0,
      permissionTexts : ['SuperAdmin', 'Admin', 'ReadWrite', 'ReadOnly', 'NoAccess'],
      show: [],
      changedBy : "",
      sending : false,
      error : false
    }),
    methods: {
      getAllMembers(id) {
        service.getOrganizationMembers(id)
          .then((response) => 
          {
            this.list = response.data
            this.loaded = true
          }).catch(
            () => this.error = true
          )
      },
      toggle(email){
        if (this.show.includes(email)){
          this.show.splice(this.show.indexOf(email),1);
        } else {
          this.show.push(email);
        }
      },
      updatePermission(user){
        this.sending = true;
        user.changedBy = this.changedBy
        service.putOrganizationMemberPermission(user,this.orgId)
        .then(() => {
          window.setTimeout(() => {
            this.loaded = false
            this.getAllMembers(this.orgId)
            this.toggle(user.email)
            this.sending = false
        }, 5000)
        }).catch(error =>
        console.log(error))
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
