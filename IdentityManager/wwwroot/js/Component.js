function getbuyerInfo(){
    return{
        
            "name":getValue("name"),
            "SubcityId":getValue("subcityId"),
            "Woreda":getValue("woreda"),
            "TinNo":getValue("tinno"),
            "LicenseNo":getValue("licenseno"),
            "LicenseImage":getValue("licenseimage"),
            "Status" : 0,
            "Phone":getValue("phone"),
          
    }
}
function getFromInput() {
    return {
        "Id": getValue("productID"),
        "Name": getValue("name"),
        "Price": getValue("price"),
        "CategoryId": getValue("category"),
        "Unit": getValue("unit"),
        "Image": getValue("image"),
        "Brand": getValue("brand"),
        "Status": getValue("status"),
        "CreatedDate": new Date(getValue("createddate"))
    };
}
function getFromInputforPost() {
    return {
        "Name": getValue("newname"),
        "Price": getValue("newprice"),
        "CategoryId": getValue("newcategory"),
        "Unit": getValue("newunit"),
        "Image": getValue("newimage"),
        "Brand": getValue("newbrand"),
        "Status": getValue("newstatus"),
        "CreatedDate": new Date(getValue("newcreateddate"))
    };
}

function setInput(product) {
    setValue("productID", product.Id);
    setValue("name", product.Name);
    setValue("price", product.Price);
    setValue("category", product.CategoryId);
    setValue("unit", product.Unit);
    setValue("image", product.Image);
    setValue("brand", product.Brand);
    setValue("status", product.Status);
    setValue("createddate", product.CreatedDate);
}
function setValue(id, value) {
    document.getElementById(id).value = value;
}
function getValue(id) {
    return document.getElementById(id).value;
}