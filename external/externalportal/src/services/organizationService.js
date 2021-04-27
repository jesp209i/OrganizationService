import axios from 'axios'

const baseurl = "http://localhost:46599/api/organization"

const exports = {
    getOrganizations : getOrganizations,
    postCreateOrganization: postCreateOrganization,
    getOrganization: getOrganization
}

export default exports


async function getOrganizations(){
    return await axios.get(baseurl);
}

function postCreateOrganization(organization) {
    console.log(organization)
    //axios.post(baseurl).then();
}

async function getOrganization(id){
    return await axios.get(baseurl+`/${id}`)
}
