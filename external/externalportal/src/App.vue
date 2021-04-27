<template>
  <div>
    <md-app>
      <md-app-toolbar class="md-primary" to="/">
        <span class="md-title" to="/">Organization overview</span>
      </md-app-toolbar>

      <md-app-drawer md-permanent="card">
        <md-list>
          <md-list-item to="/">
            <md-icon>home</md-icon>
            <span class="md-list-item-text">Home</span>
          </md-list-item>

          <md-list-item to="/organizations">
            <md-icon>toc</md-icon>
            <span class="md-list-item-text">Organizations</span>
          </md-list-item>

          <md-list-item  to="/add">
            <md-icon>add_circle_outline</md-icon>
            <span class="md-list-item-text">Add Organization</span>
          </md-list-item>

        </md-list>
      </md-app-drawer>

      <md-app-content>
        <router-view></router-view>
      </md-app-content>
    </md-app>
  </div>
</template>

<script>
  export default {
    name: 'App'
  }
</script>

<style scoped>
  .md-app {
    min-height: 250px;
    border: 1px solid rgba(#000, .12);
  }

  .md-drawer {
    width: 230px;
    max-width: calc(100vw - 125px);
  }
</style>

