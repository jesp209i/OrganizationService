import axios from 'axios'

const baseurl = "http://localhost:46599/api/organization"

const exports = {
    getOrganizations : getOrganizations,
    postCreateOrganization: postCreateOrganization,
    getOrganization: getOrganization,
    postUpdateOrganizationWebsite : postUpdateOrganizationWebsite,
    postUpdateOrganizationVatNumber: postUpdateOrganizationVatNumber,
    postUpdateOrganizationAddress: postUpdateOrganizationAddress
}

export default exports


async function getOrganizations(){
    return await axios.get(baseurl);
}

async function postUpdateOrganizationAddress(updateAddress, organizationId) {
    var request =  {
        method: 'post',
        url: `${baseurl}/${organizationId}/address`,
        data: updateAddress
    }
    
    return await axios(request);
}

async function postUpdateOrganizationVatNumber(updateVatNumber, organizationId) {
    var request =  {
        method: 'post',
        url: `${baseurl}/${organizationId}/vatnumber`,
        data: updateVatNumber
    }
    
    return await axios(request);
}

async function postUpdateOrganizationWebsite(updateWebsite, organizationId) {
    var request =  {
        method: 'post',
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
