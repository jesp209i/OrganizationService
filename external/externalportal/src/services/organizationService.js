import axios from 'axios'

const baseurl = "http://localhost:46599/api/organization"

const exports = {
    getOrganizations : getOrganizations,
    postCreateOrganization: postCreateOrganization,
    getOrganization: getOrganization,
    postUpdateOrganizationWebsite : putUpdateOrganizationWebsite,
    postUpdateOrganizationVatNumber: putUpdateOrganizationVatNumber,
    postUpdateOrganizationAddress: putUpdateOrganizationAddress,
    getOrganizationMembers: getOrganizationMembers,
    postAddOrganizationMember: postAddOrganizationMember,
    putOrganizationMemberPermission: putOrganizationMemberPermission
}

export default exports


async function getOrganizations(){
    return await axios.get(baseurl);
}

async function putUpdateOrganizationAddress(updateAddress, organizationId) {
    var request =  {
        method: 'put',
        url: `${baseurl}/${organizationId}/address`,
        data: updateAddress
    }
    
    return await axios(request);
}

async function putUpdateOrganizationVatNumber(updateVatNumber, organizationId) {
    var request =  {
        method: 'put',
        url: `${baseurl}/${organizationId}/vatnumber`,
        data: updateVatNumber
    }
    
    return await axios(request);
}

async function putUpdateOrganizationWebsite(updateWebsite, organizationId) {
    var request =  {
        method: 'put',
        url: `${baseurl}/${organizationId}/website`,
        data: updateWebsite
    }
    
    return await axios(request);
}

async function postCreateOrganization(organization) {
    var request =  {
        method: 'post',
        url: baseurl,
        data: organization
    }

    return await axios(request);
}

async function getOrganization(id){
    return await axios.get(baseurl+`/${id}`)
}

async function getOrganizationMembers(id){
    return await axios.get(baseurl+`/${id}/members`);
}

async function postAddOrganizationMember(addMember, organizationId){

    addMember.permission = Number(addMember.permission);


    var request =  {
        method: 'post',
        url: `${baseurl}/${organizationId}/members`,
        data: addMember
    }

    return await axios(request);
}

async function putOrganizationMemberPermission(user, organizationId){
    var updateModel = user
    delete updateModel.userName
    updateModel.permission = Number(updateModel.permission)
    updateModel.organizationId = organizationId
    updateModel.changeDate =  new Date().toJSON()
    var request = {
        method: 'put',
        url: `${baseurl}/${organizationId}/members/${user.email}`,
        data: updateModel
    }
    return await axios(request);
}
