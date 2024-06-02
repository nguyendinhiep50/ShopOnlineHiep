import React from 'react';
import { Layout } from 'antd';

const { Footer } = Layout;

const FooterPage: React.FC = () => {
    return (
        <Footer style={{ textAlign: 'center' }}>
            Ant Design ©{new Date().getFullYear()} Created by Ant UED
        </Footer>
    );
};

export default FooterPage;