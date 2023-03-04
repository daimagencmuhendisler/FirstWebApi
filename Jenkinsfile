node  {
    def app
    def COLOR_MAP = ['SUCCESS': 'good', 'FAILURE': 'danger', 'UNSTABLE': 'danger', 'ABORTED': 'danger']
    try{
    stage('Clone repository') {
        /* Let's make sure we have the repository cloned to our workspace */
            checkout scm
        }
    stage('Build image') {
        /* This builds the actual image; synonymous to
         * docker build on the command line */
            app = docker.build("daimagencmuhendisler/firstwebapi")
        }
    stage('Push image') {
        /* Finally, we'll push the image with two tags:
         * First, the incremental build number from Jenkins
         * Second, the 'latest' tag. 
         * Pushing multiple tags is cheap, as all the layers are reused. */
        docker.withRegistry('', 'dockerhub') {
            app.push("latest")
      }
    }

    stage('Restart Application') {
            sh "docker-compose down"
            sh "docker-compose up -d"
    }
    }
    catch(e){
                
    
    }
}
