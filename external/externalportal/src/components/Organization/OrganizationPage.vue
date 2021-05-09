<template>
  <div>
    <mdb-navbar>
      <mdb-navbar-nav nav left>
        <mdb-nav-item :to="{ name: 'orginfo', params: {id: orgId }}" active>Details</mdb-nav-item>
        <mdb-nav-item :to="{ name: 'orgmembers', params: {id: orgId }}">Members</mdb-nav-item> 
        <mdb-nav-item :to="{ name: 'orgnewmember', params: {id: orgId }}">Add Member</mdb-nav-item> 
      </mdb-navbar-nav>
    </mdb-navbar>
    <router-view></router-view>    
  </div>
</template>
<script>
  import { mdbNavbar, mdbNavbarNav, mdbNavItem } from 'mdbvue';
  export default {
    name: 'OrganizationPage',
    data: () =>({
      orgId : 0
    }),
    components: {
      mdbNavbar,
      mdbNavbarNav,
      mdbNavItem
    },
    created() {
      this.orgId = this.$route.params.id
    }
  }
</script>
