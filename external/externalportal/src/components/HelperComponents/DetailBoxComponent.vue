<template>
  <div :class="['detail-box', {'changing-box': isChanging}]">
    <mdb-row :class="[{'changing': isChanging}]">
      <mdb-col>
        <span class="heading">{{title}}</span>
      </mdb-col>
      
    </mdb-row>
    <slot>Content goes here</slot>
    <mdb-row :class="{'input-padding': isChanging}">
      <mdb-col>
        <div class="actions">
        <slot name="actions">
          <br>
        </slot>
        </div>
      </mdb-col>
    </mdb-row>
  </div>
</template>

<script>
import { mdbRow, mdbCol } from 'mdbvue'
export default {
    name: "DetailBoxComponent",
    components: {
      mdbRow, mdbCol
    },
    props: ['title', 'changing'],
    computed: {
      isChanging: function(){
        return this.changing != undefined
      }
    }
}
</script>
<style scoped>
.heading {
 font-weight: 900;
 font-size: 120%;
}
.detail-box{
  
  padding-bottom: 5px;
  border-bottom: 2px solid #ccc;
}
.actions {
  float:right;
  margin-right: 20px;
}
.changing {
  background: #ccc;
  padding: 5px;
}
.input-padding{
  background: #eee;
}
</style>

