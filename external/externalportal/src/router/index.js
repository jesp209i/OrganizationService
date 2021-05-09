import Vue from 'vue'
import VueRouter from 'vue-router'

import Main from '@/components/Main'
import OrganizationList from '@/components/OrganizationList'
import AddOrganization from '@/components/AddOrganization'
import OrganizationDetail from '@/components/Organization/OrganizationDetail'
import MemberList from '@/components/Members/MemberList'
import OrganizationPage from '@/components/Organization/OrganizationPage'
import NewMember from '@/components/Members/NewMember'
import SearchOrganization from '@/components/Members/SearchOrganization'
import Organizations from '@/components/Organizations'
Vue.use(VueRouter)

const router = new VueRouter({
    mode: 'history',
    routes : [
      { path: '/', component: Main },
      { path: '/organizations', 
        component: Organizations,
        children: [
          {
            path: "add",
            component: AddOrganization
          },
          { 
            path: "list",
            component: OrganizationList
          }
        ]
      },
      { path: '/search', component: SearchOrganization },
      { 
        path: '/organization/:id', 
        component: OrganizationPage, 
        props: { default: true},
        children: [
          {
            path: 'info',
            component: OrganizationDetail,
            props: {default: true},
            name: 'orginfo'

          },
          {
            path: 'members',
            component: MemberList,
            props: { default: true},
            name: 'orgmembers'
          },
          {
            path: 'newmember',
            props: { default: true},
            component: NewMember,
            name: 'orgnewmember'
          }
        ]
      },
    ]
  })

export default router