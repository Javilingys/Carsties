/** @type {import('next').NextConfig} */
const nextConfig = {
    experimental: {
        serverActions: true
    },
    images: {
        domains: [
            'cdn.pixabay.com',
            'sun9-48.userapi.com',
            'sun9-19.userapi.com',
            'sun9-28.userapi.com',
            'sun9-30.userapi.com',
            'sun9-50.userapi.com',
            'sun9-53.userapi.com',
            'sun9-21.userapi.com',
            'sun9-39.userapi.com',
            'sun9-60.userapi.com',
            'sun1-21.userapi.com',
        ]
    },
    output: 'standalone'
}

module.exports = nextConfig
