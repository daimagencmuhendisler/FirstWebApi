
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
            app = docker.build("tasmehmetcan/dockerjenkinssampleapp")
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
   stage('Slack Notification')
    {
             slackSend channel: '#yourchannel',
                    color: COLOR_MAP[currentBuild.getCurrentResult()],
                    tokenCredentialId:'slackCredentials',
                    message: "*${currentBuild.getCurrentResult()}:* Job ${env.JOB_NAME} build ${env.BUILD_NUMBER}\n More info at: ${env.BUILD_URL}"
    }
    }
    catch(e){
                slackSend channel: '#yourchannel',
                    color: 'danger',
                    tokenCredentialId:'slackCredentials',
                    message: "*ERROR:* Job ${env.JOB_NAME} build ${env.BUILD_NUMBER}\n Description : ${e}\n More info at: ${env.BUILD_URL}"
    
    }
}
