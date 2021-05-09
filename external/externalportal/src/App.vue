<template>
  <mdb-container>
      <mdb-navbar color="indigo" dark>
        <mdb-navbar-brand to="/"> 
          Site
        </mdb-navbar-brand>
        <mdb-navbar-toggler>
          <mdb-navbar-nav>
            <mdb-nav-item to="/organizations/list">Organizations</mdb-nav-item>
            <mdb-nav-item to="/search">Search</mdb-nav-item>
          </mdb-navbar-nav>
        </mdb-navbar-toggler>
      </mdb-navbar>
    <mdb-row>
      <mdb-col><router-view></router-view> </mdb-col>
    </mdb-row>
  </mdb-container>
</template>

<script>
  import {mdbContainer, mdbRow, mdbCol, mdbNavbar, mdbNavbarBrand, mdbNavbarToggler, mdbNavbarNav, mdbNavItem } from 'mdbvue'

  export default {
    name: 'App',
    components: {
      mdbContainer, 
      mdbRow, 
      mdbCol, 
      mdbNavbar,
      mdbNavbarBrand,
      mdbNavbarToggler,
      mdbNavbarNav,
      mdbNavItem
    }
  }
</script>

<style scoped>
@import url('https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap');
</style>

