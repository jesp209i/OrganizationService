import Vue from 'vue'
import VueRouter from 'vue-router'

import Main from '@/components/Main'
import OrganizationList from '@/components/OrganizationList'
import AddOrganization from '@/components/AddOrganization'
import OrganizationDetail from '@/components/Organization/OrganizationDetail'
import MemberList from '@/components/Members/MemberList'

Vue.use(VueRouter)

const router = new VueRouter({
    mode: 'history',
    routes : [
      { path: '/', component: Main },
      { path: '/organizations', component: OrganizationList },
      { path: '/add', component: AddOrganization },
      { 
        path: '/organization/:id', 
        component: OrganizationDetail, 
        props : { default: true }
      },
      { path: '/members', component: MemberList}
    ]
  })

export default router