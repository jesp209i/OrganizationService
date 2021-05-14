<template>
<div class="mx-auto loading" v-if="isLoading">
  <div v-if="!hasError">
    <div class="loading-text">
    Loading - please wait
    </div>
    <div class="spinner-border" role="status">
      <span class="sr-only">Loading...</span>
    </div>
    <div class="loading-friendly-text">
      {{message}}
    </div>
  </div>
  <div v-if="hasError"> 
    Some error occurred I cannot recover from
  </div>
  </div>
</template>
<script>
export default {
  name: "LoadingScreen",
  props: ['loading', 'error'],
  computed: {
    isLoading: function(){
      if (this.loading === undefined || this.loading === true)
        return true;
      this.stop();
      return false;
    },
    hasError: function(){
      if (typeof this.error !== undefined && this.error === true)
        return true
      return false
    }
  },
  data: () =>({
    message : '',
    interval : null,
    notusedmessages : ['Im taking care of my procrastination problems, just you wait and see','This is taking a while', 'Please wait just some more', 'I haven\'t forgotten about you', 'Still loading...', 'Not quite there yet', 'What? Im slow?', 'Im still running']
  }),
  methods: {
    startMessages() {
      this.interval = setInterval(() =>{
        let newmessage = this.notusedmessages.pop();
        this.message = newmessage;
        }, 15000);
    },
    stop(){
      clearInterval(this.interval);
    }
  },
  created(){
    this.startMessages()
  }
}
</script>
<style scoped>
.loading {
  margin-top: 20px;
  text-align: center;
}
.loading-text{
  font-size: 120%;
  font-weight: 900;
  margin-bottom: 20px;
}
.loading-friendly-text{
  margin-top:20px;
}
.loading-error-text{
    font-size: 120%;
  font-weight: 900;
  margin-top:20px;
}

</style>
