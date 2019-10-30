
class Util{
    // cordova.file.externalRootDirectory
    create_dir_recursive(path){
        const dirs = path.split("/");
        // console.log(JSON.stringify(dirs))
        return new Promise((resolve, reject) => {
            window.resolveLocalFileSystemURL(cordova.file.externalRootDirectory, (dirEntry)=> {
                // console.log(JSON.stringify(dirEntry))
                function create_sub_dir(parent, subs){
                    // console.log(`parent=${JSON.stringify(parent)}; subs=${JSON.stringify(subs)}`)
                    const sub = subs.shift();
                    if(sub){
                        parent.getDirectory(sub, { create: true }, subDirEntry=>{
                            create_sub_dir(subDirEntry, subs)
                        }, err=>reject(err));
                    } else{
                        resolve(parent)
                    }                
                }
                create_sub_dir(dirEntry, dirs);
            }, err=>reject(err));
        });        
    }
    get_fileEntry(path){
        return new Promise((resolve, reject) => {
            window.resolveLocalFileSystemURL(path, (fileEntry)=> {
                resolve(fileEntry);
            }, err=>reject(err));
        }); 
    }
}

export default new Util;