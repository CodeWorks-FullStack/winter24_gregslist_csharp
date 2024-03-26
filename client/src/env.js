export const dev = window.location.origin.includes('localhost')
// TODO don't forget to update your baseURL for dotnet
export const baseURL = dev ? 'https://localhost:7045' : ''
export const useSockets = false

// TODO change to your own Auth credentials, create appsettings.Development.json in root folder of server
export const domain = 'dev-h63x8ohlbl1q2qkp.us.auth0.com'
export const clientId = 'XX15k7a9Be1KE1Usl1aaOrDdzKJwvtUp'
export const audience = 'https://jeremyisaraddude.com'
