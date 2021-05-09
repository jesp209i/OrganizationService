<template>
  <div>
    <mdb-navbar>
      <mdb-navbar-nav nav left>
        <mdb-nav-item to="/organizations/add" active>Add Organization</mdb-nav-item>
        <mdb-nav-item to="/organizations/list">List</mdb-nav-item> 
      </mdb-navbar-nav>
    </mdb-navbar>

    <router-view></router-view>

  </div>
</template>
<script>
import { mdbNavbar, mdbNavbarNav, mdbNavItem} from 'mdbvue';


export default {
  name: "Organizations",
  components: {
    mdbNavbar, mdbNavbarNav, mdbNavItem
  }
}
</script>
